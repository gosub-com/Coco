1 POKE 150,7::'4800 BAUD (9600)
5 JMS F
10 DIM K(7,255)
20 FORX=0TO255:A=INT(X/4):B=INT(A/8):C=A-B*8:K(B,X)=INT(2^(7-C)):NEXT
27 PRINT#-2,CHR$(27);CHR$(65);CHR$(8)
30 FORA=0TO364000STEP1920:PRINT#-2:FORB=0TO7:PRINT#-2:PRINT#-2,CHR$(27);"z";CHR$(&H80);CHR$(7);:FORC=A TOA+1920-1:PRINT#-2,CHR$(K(B,BUTTON(C)));:NEXT C,B,A
