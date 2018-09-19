import { Directive, TemplateRef, ViewContainerRef, Input } from '@angular/core';

@Directive({
    selector: '[Directive1]'
})
export class Directive1Directive {

    

    constructor(private templateRef: TemplateRef<any>, private viewContainer: ViewContainerRef) {
        console.log('Directive1Directive constructor');
        console.log('templateRef');
        console.log(templateRef);
        console.log('viewContainer');
        console.log(viewContainer);
    }

    @Input() set Directive1(data: boolean) {

        console.log(data);
        if (data == true) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else if (data == false) {
            this.viewContainer.clear();
        }
    }

}
