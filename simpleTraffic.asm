;portD - 2Dh
;portB - 2Bh
;portG - B1h

;O1 - 2s
;O2 - 13s (Ch)

;01 czerwony
;10 pomaranczowy
;11 czerwony+pomaranczowy
;00 zielony

org 100h

;INIT
call setGreenAx
call setMainFromAx
call setRedAx
call setSideFromAx

;MAIN PROGRAM LOGIC

mainLoop:
in ax, 0x2D
cmp al, 0x00    
jz mainLoop
call sensorPassed
jmp mainLoop

sensorPassed:
call setMainOrangeWaitO1
call setSideMixedWaitO1
call setMainRedWait01
call setSideGreenWait02

call setSideOrangeWaitO1
call setMainMixedWaitO1
call setSideRedWait01
call setMainGreen

call clearSensor
ret

;CYCLE IMPLEMENTATION

setMainOrangeWaitO1:
call setOrangeAx
call setMainFromAx
call delay2s 
ret

setSideMixedWaitO1:
call setMixedAx
call setSideFromAx
call delay2s 
ret

setMainRedWait01:
call setRedAx
call setMainFromAx
call delay2s 
ret

setSideGreenWait02:
call setGreenAx
call setSideFromAx
call delay13s 
ret

setSideOrangeWaitO1:
call setOrangeAx
call setSideFromAx
call delay2s 
ret

setMainMixedWaitO1:
call setMixedAx
call setMainFromAx
call delay2s 
ret

setSideRedWait01:
call setRedAx
call setSideFromAx
call delay2s 
ret

setMainGreen:
call setGreenAx
call setMainFromAx
ret

;SET LIGHTS (COLOUR)

setGreenAx:
mov ax, 00b
ret

setRedAx:
mov ax, 01b
ret

setOrangeAx:
mov ax, 10b
ret

setMixedAx:
mov ax, 11b
ret

;SET LIGHTS (ROAD)

setMainFromAx:
out 0xB1, ax
ret

setSideFromAx:
out 0x2B, ax
ret

;DELAY

delay2s:
mov cx, 0x1E
mov dx, 0x8480
call delay
ret

delay13s:
mov cx, 0xC6
mov dx, 0x5D40
call delay
ret

delay:
mov al, 0x0
mov ah, 0x86
int 0x15
ret

;ENDING ROUTINE

clearSensor:
mov ax, 0x0
out 0x2D, ax 
ret