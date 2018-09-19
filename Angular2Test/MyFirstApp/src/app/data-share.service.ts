import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';


@Injectable()
export class DataShareService {
  public static myVar2 :string=" "
  private myVar1= new BehaviorSubject<string>("");
  crMyVar1 = this.myVar1.asObservable();
  constructor() { }
  setMyVal1(newVar)
  {
    this.myVar1.next(newVar)
  }
}
