using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoDisk
{
    class CocoDisk
    {
        const int SECTOR_SIZE = 256;
        const int TRACK_SIZE = 18 * 256;
        const int GRANULE_SIZE = 9 * 256;
        const int MIN_DISK_SIZE = 18 * 18 * 256; // Enough space to hold the directory
        const int MAX_DISK_SIZE = GRANULE_SIZE * 192; // Don't overflow granule table
        const int MAX_FILES = 72;
        const int FAT_INDEX = 17 * TRACK_SIZE + 1 * SECTOR_SIZE;
        const int DIR_INDEX = 17 * TRACK_SIZE + 2 * SECTOR_SIZE;
        const int DIR_ENTRY_SIZE = 32;
        static readonly byte[] SECTOR_ERROR = Encoding.UTF8.GetBytes("***BAD SECTOR!\r\n");

        byte[] mDisk = new byte[0];
        int mErrorsOnDisk;
        int mErrorsInFiles;
        CocoFile[] mFiles = new CocoFile[0];

        public byte[] Disk => mDisk;
        public CocoFile[] Files => mFiles;
        public int ErrorsOnDisk => mErrorsOnDisk;
        public int ErrorsInFiles => mErrorsInFiles;

        public CocoDisk()
        {
        }

        public CocoDisk(byte[] disk)
        {
            Load(disk);
        }

        /// <summary>
        /// Loads a disk file (the array is copied)
        /// </summary>
        public void Load(byte[] disk)
        {
            // All of the code assumes the following conditions are met, so check them first
            if (disk.Length < MIN_DISK_SIZE)
                throw new Exception("Disk file is too small.  The file must be at least " + MIN_DISK_SIZE + " bytes.");
            if (disk.Length >= MAX_DISK_SIZE)
                throw new Exception("Disk file is too big.  The file must be smaller than " + MAX_DISK_SIZE + " bytes.");
            if (disk.Length % TRACK_SIZE != 0)
                throw new Exception("Incorrect file size.  The file must have an integer number of tracks.  The file size must be divisible by " + TRACK_SIZE);

            // Load files
            disk = (byte[])disk.Clone();
            mDisk = disk;
            var files = new List<CocoFile>();
            for (int i = 0; i < MAX_FILES; i++)
            {
                var file = LoadFile(i);
                if (file != null)
                    files.Add(file);
            }
            mFiles = files.ToArray();

            // Count errors
            mErrorsOnDisk = 0;
            mErrorsInFiles = 0;
            for (int i = 0; i < disk.Length; i += SECTOR_SIZE)
                if (SectorHasError(i))
                    mErrorsOnDisk++;
            foreach (var file in mFiles)
                mErrorsInFiles += file.ErrorCount;
        }

        /// <summary>
        /// Load a file, returns NULL if there is no file there
        /// </summary>
        CocoFile LoadFile(int index)
        {
            var disk = mDisk;
            int entryIndex = DirEntryIndex(index);
            if (disk[entryIndex] == 0 || disk[entryIndex] == 255)
                return null;

            var name = Encoding.UTF8.GetString(disk, entryIndex, 8).TrimEnd()
                            + "." + Encoding.UTF8.GetString(disk, entryIndex + 8, 3).Trim();
            int type = disk[entryIndex + 11];
            int ascii = disk[entryIndex + 12];
            int granule = disk[entryIndex + 13];
            int bytesInLastSector = 256 * disk[entryIndex + 14] + disk[entryIndex + 15];
            if (granule >= 192)
                throw new Exception("The file granule pointer is invalid.");
            if (bytesInLastSector > 256)
                throw new Exception("Bytes in last sector is invalid.");

            // Read granules
            var fileData = new List<byte>();
            var granules = new List<int>();
            int errorCount = 0;
            var nextGranule = disk[FAT_INDEX + granule];
            while (nextGranule < 192)
            {
                // Prevent infinite loop
                if (granules.Contains(granule))
                    throw new Exception("The FAT contains an infinite loop.");
                granules.Add(granule);

                // Read the whole granule
                int dataIndex = GranuleToIndex(granule);
                if (dataIndex + GRANULE_SIZE > disk.Length)
                    throw new Exception("The FAT points to a granule that doesn't exist on the disk.");
                for (int i = 0; i < GRANULE_SIZE; i++)
                    fileData.Add(disk[dataIndex++]);
                errorCount += GranuleErrorCount(granule, GRANULE_SIZE);

                // Move to next granule
                granule = nextGranule;
                nextGranule = disk[FAT_INDEX + granule];
            }

            // Read final granule
            if (nextGranule > 201)
                throw new Exception("An invalid FAT entry was found");
            int dataIndex2 = GranuleToIndex(granule);
            int lastGranuleSize = 256 * (nextGranule - 193) + bytesInLastSector;
            if (dataIndex2 + lastGranuleSize > disk.Length)
                throw new Exception("The FAT points to a granule that doesn't exist on the disk.");
            for (int i = 0; i < lastGranuleSize; i++)
                fileData.Add(disk[dataIndex2++]);
            errorCount += GranuleErrorCount(granule, lastGranuleSize);

            // Save file
            var file = new CocoFile();
            file.Name = name;
            file.Data = fileData.ToArray();
            file.Type = (CocoFileType)type;
            file.ErrorCount = errorCount;

            // Figure file type
            bool isAscii = true;
            foreach (var b in file.Data)
                if (b == 0 || b > 127)
                    isAscii = false;

            if (type == 0 && !isAscii)
                file.Type = CocoFileType.Basic; // Basic format (type 0 is basic)
            else if (type == 0 && isAscii)
                file.Type = CocoFileType.Ascii; // Basic, but saved as ASCII
            else if (type == 2)
                file.Type = CocoFileType.Binary; // Type 2 is machine language
            else
                file.Type = isAscii ? CocoFileType.Ascii : CocoFileType.Binary;
            return file;
        }

        // Convert granule number to index on the disk
        int GranuleToIndex(int granule)
        {
            int index = granule * GRANULE_SIZE;
            if (index >= 17 * TRACK_SIZE)
                index += TRACK_SIZE;
            return index;
        }

        // Get the index of the file on the disk
        int DirEntryIndex(int entry)
        {
            return entry * DIR_ENTRY_SIZE + DIR_INDEX;
        }

        // Counts sector errors in the granule
        int GranuleErrorCount(int granule, int size)
        {
            int index = GranuleToIndex(granule);
            int errorCount = 0;
            for (int i = 0; i < size; i += SECTOR_SIZE)
            {
                if (SectorHasError(index + i))
                    errorCount++;
            }
            return errorCount;
        }

        // Must be called with a sector aligned index (i.e. divisible by 256)
        bool SectorHasError(int index)
        {
            for (int i = 0; i < SECTOR_ERROR.Length; i++)
                if (SECTOR_ERROR[i] != mDisk[index++])
                    return false;
            return true;
        }

        /// <summary>
        /// Clears any unused sectors, returns the number of sectors that were modified.
        /// </summary>
        public int ClearUnusedSectors()
        {
            if (mDisk.Length == 0)
                return 0;

            int modifiedSectors = 0;
            for (int granule = 0; GranuleToIndex(granule) < mDisk.Length; granule++)
            {
                int fatIndex = mDisk[FAT_INDEX + granule];
                if (fatIndex < 192)
                    continue;  // Entire granule used
                int sectorsUsed = fatIndex == 255 ? 0 : fatIndex - 192;
                for (int sector = sectorsUsed; sector < 9; sector++)
                {
                    if (ClearSector(GranuleToIndex(granule) + 256 * sector))
                        modifiedSectors++;
                }
            }
            Load(mDisk);
            return modifiedSectors;
        }

        // Returns TRUE if the sector was modified.
        // Coco uses 255 for empty sectors
        bool ClearSector(int index)
        {
            bool sectorModified = false;
            for (int i = index; i < index + SECTOR_SIZE; i++)
            {
                if (mDisk[i] != 255)
                    sectorModified = true;
                mDisk[i] = 255;
            }
            return sectorModified;
        }

        public void ShrinkDisk()
        {
            var freeGranule = 0;
            for (int granule = 0; GranuleToIndex(granule) < mDisk.Length; granule++)
            {
                int fatIndex = mDisk[FAT_INDEX + granule];
                if (fatIndex != 255)
                {
                    MoveGranule(granule, freeGranule);
                    freeGranule++;
                }
            }

            int newDiskSize = Math.Max(MIN_DISK_SIZE, GranuleToIndex(freeGranule));
            if (newDiskSize % TRACK_SIZE != 0)
                newDiskSize = ((newDiskSize / TRACK_SIZE) + 1) * TRACK_SIZE;

            var newDisk = new byte[newDiskSize];
            Array.Copy(mDisk, newDisk, newDisk.Length);
            mDisk = newDisk;

            Load(mDisk);
        }

        // Move a granule from one place to another, including the FAT/file pointers.
        void MoveGranule(int granuleFrom, int granuleTo)
        {
            if (granuleFrom == granuleTo)
                return;

            // Copy data
            int indexFrom = GranuleToIndex(granuleFrom);
            int indexTo = GranuleToIndex(granuleTo);
            for (int i = 0; i < GRANULE_SIZE; i++)
                mDisk[indexTo++] = mDisk[indexFrom++];

            // Update FAT
            mDisk[FAT_INDEX + granuleTo] = mDisk[FAT_INDEX + granuleFrom];
            mDisk[FAT_INDEX + granuleFrom] = 255; // Free it
            for (int granule = 0; GranuleToIndex(granule) < mDisk.Length; granule++)
                if (mDisk[FAT_INDEX + granule] == granuleFrom)
                    mDisk[FAT_INDEX + granule] = (byte)granuleTo;

            // Update file fat pointers
            for (int entry = 0; entry < MAX_FILES; entry++)
            {
                int entryIndex = DirEntryIndex(entry);
                if (mDisk[entryIndex + 13] == granuleFrom)
                    mDisk[entryIndex + 13] = (byte)granuleTo;
            }
        }
    }
}
