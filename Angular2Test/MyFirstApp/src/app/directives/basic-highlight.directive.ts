import { Directive,ElementRef,OnInit,Renderer2,HostListener,HostBinding,Input } from '@angular/core';

@Directive({
  selector: '[basicHighlight]'
})
export class BasicHighlightDirective implements OnInit  {

  constructor(private elmtRef: ElementRef,private rend: Renderer2) {

     }

   ngOnInit(){
     // remember it is not recommended to access DOM by this way
    //this.elmtRef.nativeElement.style.backgroundColor='green';
    
    // this the recommended way to access DOM 
    //this.rend.setStyle(this.elmtRef.nativeElement,'background-color','blue');
   }
   @Input('hlColor')
   @Input('hlColor') highLightColor: string="red";
   @HostBinding('style.backgroundColor')  bgColor1: string='white';
   
   @HostListener('mouseenter') mouseover1(e:Event){
     console.log('mouseenter');
    //this.rend.setStyle(this.elmtRef.nativeElement,'background-color','blue');
    this.bgColor1=this.highLightColor;
    
    
    } 

    @HostListener('mouseout') mouseout1(e:Event){
      console.log('mouseout');
      //this.rend.setStyle(this.elmtRef.nativeElement,'background-color','white');
      this.bgColor1='white';
      }
   

}
