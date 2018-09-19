import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-comp2',
  templateUrl: './comp2.component.html',
  styleUrls: ['./comp2.component.css']
})
export class Comp2Component implements OnInit {
  
  private id: number;
  private sub: any;

  constructor(private route: ActivatedRoute, private router: Router) 
  {

   }

  ngOnInit() {
    console.log(this.route.snapshot.params['id']);
    console.log(this.route.snapshot.params['name']); ///app1/comp2/1;name=asd2 name is optional param
   this.sub = this.route.params.subscribe(params => {
       this.id = +params['id']; // (+) converts string 'id' to a number
        console.log(this.id);
       // In a real app: dispatch action to load the details here.
    });
  }

}
