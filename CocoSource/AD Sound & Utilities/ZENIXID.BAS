1 POKE 65497,0
10 POKE 150,7
20 PRINT#-2,CHR$(27);"E";
25 FOR N=10101 TO 10110
30 PRINT#-2,"GOSUB SOFTWARE PRESENTS"
40 PRINT#-2
45 PRINT#-2,CHR$(27);"W";CHR$(1);
50 PRINT#-2,"   ZENIX"
55 PRINT#-2,CHR$(27);"W";CHR$(0);
60 PRINT#-2
65 N$=RIGHT$("000000"+MID$(STR$(N),2,255),6)
70 PRINT#-2,"REGISTRATION #";N$
80 PRINT#-2
90 NEXT
