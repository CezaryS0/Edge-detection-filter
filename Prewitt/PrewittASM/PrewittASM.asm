.data
Prewitt3x3Horizontal DQ 1,  0,  -1, 1,  0,  -1, 1,  0,  -1

Prewitt3x3Vertical	 WORD 1,  1,  1
					 WORD 0,  0,  0
					 WORD -1, -1, -1

.code
ASMPrewittDLL proc
	movq xmm3, rcx ;pixelBuffer
	movq xmm4, rdx ; RGB
	movq xmm5, r8  ;byteOffset
	movq xmm6, r9  ;stride 
	mov r10,-1 ;r10 = filterY

forloop1:

	mov r11,-1 ;r11 = filterX
	forloop2:
		
		;RGB[0] = blueX
		;RGB[1] = greenX
		;RGB[2] = redX
		;RGB[3] = blueY
		;RGB[4] = greenY
		;RGB[5] = redY
		
		movq r8,xmm5
		mov rax,r11
		mov rbx,4
		mul rbx
		add r8,rax
		mov rax,r10
		movq r9,xmm6
		mul r9
		add r8,rax ;r8 = calcOffset
;---------------------------------------------------- RGB[0] += pixelBuffer[calcOffset] * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];

		xor rcx,rcx
			inner_loopA:
				mov r13,r11  ;filterX
				add r13,1
				mov r12,r10  ;filterY								
				add r12,1
				mov rax,r12
				mov rbx,3
				mul rbx
				add rax,r13
				
				lea rsi, [Prewitt3x3Horizontal]
				mov rsi, qword ptr[rsi+rax*8]
				CVTSI2SD xmm0,rsi
				
				movq rdx,xmm3 ;pixelBuffer
				lea rdx,[rdx]
				mov rbx,r8 ;calcOffset
				add rbx,rcx

				xor rax,rax
				mov al,byte ptr[rdx+rbx]
				CVTSI2SD xmm1,rax ;pixelBuffer[calcOffset]
				

				MULSD xmm0,xmm1

				movq r9,xmm4
				mov rax,[r9+rcx*8]
				movq rax,xmm2
				ADDSD xmm2,xmm0 ;RGB[i]
				movq rax,xmm2
				mov [r9+rcx*8],rax
				ret
				inc rcx
				cmp rcx,3
			jl inner_loopA
;---------------------------------------------------
		xor rcx,rcx
			inner_loopB:
				mov r13, r11 ;filterX
				add r13,1
				mov r12,r10  ;filterY								
				add r12,1
				mov rax,r12
				mov rbx,3
				mul rbx
				add rax,r13

				lea rsi, [Prewitt3x3Vertical]
				mov rsi, qword ptr[rsi+rax*8]
				CVTSI2SD xmm0,rsi

				movq rdx,xmm3 ;pixelBuffer
				lea rdx,[rdx]
				mov rbx,r8 ;calcOffset
				add rbx,rcx

				xor rax,rax
				mov al,byte ptr[rdx+rbx]
				CVTSI2SD xmm1,rax ;pixelBuffer[calcOffset]

				MULSD xmm0,xmm1

				movq r9,xmm4
				add rcx,3
				mov rax, [r9+rcx*8]
				movq xmm2,rax
				ADDSD xmm2,xmm0 ;RGB[i]
				movq rax,xmm2
				mov [r9+rcx*8],rax
				sub rcx,3
				inc rcx
				cmp rcx,3
			jl inner_loopB
;---------------------------------------------------
		inc r11
		cmp r11,1
	jle forloop2
	inc r10
	cmp r10,1
	jle forloop1
ret
ASMPrewittDLL endp
end
