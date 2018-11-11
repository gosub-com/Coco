       ORG   $7000
* WAIT FOR A ONE
GETBIT CLRB
EX000  ORCC  #$50
       LDX   #$E00
       LDA   $FF22
       ANDA  #$01
       BEQ   EX000
* WAIT FOR A ZERO
EX010  LDA   $FF22
       ANDA  #$01
       BNE   EX010
* COUNT LENGTH OF ZERO
EX020  LDA   $FF22
       STA   ,X+
       CMPX  #$17F0
       BLO   EX020
       RTS
EXEC   BSR   GETBIT
       RTS
       END   EXEC




