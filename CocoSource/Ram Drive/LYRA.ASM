       ORG   $7000
VAL1   FCB   0
VAL2   FCB   0
VAL3   FCB   0
VAL4   FCB   0
* WAIT FOR A ONE
GETBIT CLRB
EX000  LDA   $FF22
       ANDA  #$01
       BEQ   EX000
* WAIT FOR A ZERO
EX010  LDA   $FF22
       ANDA  #$01
       BNE   EX010
* COUNT LENGTH OF ZERO
EX020  INCB
       LDA   $FF22
       ANDA  #$01
       BEQ   EX020
       RTS
EXEC   BSR   GETBIT
       STB   VAL1
       BSR   GETBIT
       STB   VAL2
       BSR   GETBIT
       STB   VAL3
       BSR   GETBIT
       STB   VAL4
       RTS
       END   EXEC


