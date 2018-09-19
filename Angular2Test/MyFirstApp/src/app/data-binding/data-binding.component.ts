import { Component  } from '@angular/core';


@Component({
    selector: 'DataBinding',
    templateUrl: './data-binding.component.html',
    styleUrls: ['./data-binding.component.css']
})
export class DataBindingComponent   {
    name = 'UserData 1';
    lableClass = 'lable2';

    public titleClass: string = "Title";
    public addTitleClass: boolean = false;
    public myStyle: any = { 'color': 'red' };
    public myStyleColor: string = "red";
    public myValue: string = "welcome";

    

    constructor() {
        console.log('constructor');
    }
    
    

    btn1Click(event: any) {
        console.log('Click');
        console.log(event);
    }

    btn1MouseOver(event: any) {

    }

    txtUserName_keyup(txtUserName : any)
    {
        console.log(txtUserName.value);
        console.log(txtUserName.data);
    } 

    text_Ckange(data: any) {
        console.log(data);
    }

    
}
