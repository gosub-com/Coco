10 JMS F
20 POKE 150,7
30 DIM N(10,11,8),P(8)
31 P(0)=128:P(1)=64:P(2)=32
32 P(3)=16:P(4)=8:P(5)=4
33 P(6)=2:P(7)=1
40 FOR N=0 TO 10:PRINTSTR$(N);
50 FOR Y=0 TO 7
60 READ A$
70 FOR X=1 TO 11
80 N(N,X,Y)=VAL(MID$(A$,X,1))
90 NEXT X,Y,N
100 PRINT
120 PRINT#-2,CHR$(27);"*";CHR$(1);"09";
140 FOR N=0 TO 9:PRINTSTR$(N);
150 PRINT#-2,CHR$(128+16+11);
160 FOR X=1 TO 11:T=0
170 FOR Y=0 TO 7
180 T=T+N(N,X,Y)*P(Y)
190 NEXT Y:PRINT#-2,CHR$(T);
200 NEXT X,N
220 PRINTSTR$(10)
230 PRINT#-2,CHR$(27);"*";CHR$(1);"..";CHR$(128+16+11);
240 FOR X=1 TO 11:T=0
250 FOR Y=0 TO 7
260 T=T+N(10,X,Y)*P(Y)
270 NEXT Y:PRINT#-2,CHR$(T);
280 NEXT X
290 PRINT#-2,CHR$(27);"$1";
300 END
1000 DATA "           "
1001 DATA "           "
1002 DATA "   1 1 1   "
1003 DATA " 1       1 "
1004 DATA "1         1"
1005 DATA " 1       1 "
1006 DATA "   1 1 1   "
1007 DATA "           "
1100 DATA "           "
1101 DATA "           "
1102 DATA "1          "
1103 DATA "1        1 "
1104 DATA "1 1 1 1 1 1"
1105 DATA "1          "
1106 DATA "1          "
1107 DATA "           "
1200 DATA "           "
1201 DATA "           "
1202 DATA "1 1      1 "
1203 DATA "1  1      1"
1204 DATA "1   1     1"
1205 DATA "1    1   1 "
1206 DATA "1     1 1  "
1207 DATA "           "
1300 DATA "           "
1301 DATA "           "
1302 DATA " 1       1 "
1303 DATA "1    1    1"
1304 DATA "1    1    1"
1305 DATA " 1   1   1 "
1306 DATA "  1 1 1 1  "
1307 DATA "           "
1400 DATA "           "
1401 DATA "           "
1402 DATA "     1 1 1 "
1403 DATA "     1     "
1404 DATA "     1     "
1405 DATA "1 1 1 1 1 1"
1406 DATA "     1     "
1407 DATA "           "
1500 DATA "           "
1501 DATA "           "
1502 DATA " 1  1 1 1 1"
1503 DATA "1    1    1"
1504 DATA "1     1   1"
1505 DATA " 1   1    1"
1506 DATA "  1 1     1"
1507 DATA "           "
1600 DATA "           "
1601 DATA "           "
1602 DATA "  1 1 1 1  "
1603 DATA "1   1     1"
1604 DATA "1    1    1"
1605 DATA "1    1    1"
1606 DATA "  1 1    1 "
1607 DATA "           "
1700 DATA "           "
1701 DATA "           "
1702 DATA "          1"
1703 DATA "          1"
1704 DATA "1 1 1     1"
1705 DATA "     1 1  1"
1706 DATA "        1 1"
1707 DATA "           "
1800 DATA "           "
1801 DATA "           "
1802 DATA " 1 1   1 1 "
1803 DATA "1    1    1"
1804 DATA "1    1    1"
1805 DATA "1    1    1"
1806 DATA " 1 1   1 1 "
1807 DATA "           "
1900 DATA "           "
1901 DATA "           "
1902 DATA "       1 1 "
1903 DATA "1    1    1"
1904 DATA "1    1    1"
1905 DATA "1    1    1"
1906 DATA " 1 1 1 1 1 "
1907 DATA "           "
2900 DATA "           "
2901 DATA "           "
2902 DATA "           "
2903 DATA " 1 1       "
2904 DATA " 1 1       "
2905 DATA "           "
2906 DATA "           "
2907 DATA "           "
