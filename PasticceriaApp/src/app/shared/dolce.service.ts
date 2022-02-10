import { Injectable } from '@angular/core';
import { Dolce } from './dolce.model';
import { HttpClient } from "@angular/common/http";



@Injectable({
  providedIn: 'root'
})
export class DolceService {

  constructor(private http:HttpClient) { }

  formData:Dolce = new Dolce();

  readonly baseUrl = 'http://localhost:5057/api/Dolci'

  list : Dolce[];

  returnNome(id:number){
    if (this.list){
      var dolceNome;
      for (let i = 0; i < this.list.length; i++) {
        if(this.list[i].dolceId==id){
          dolceNome = this.list[i].nome;
        }
      }
      return dolceNome;
    }
    else
      return null;
  }

  postDolce() {
    return this.http.post(this.baseUrl,this.formData)
  }

  putDolce() {
    return this.http.put(`${this.baseUrl}/${this.formData.dolceId}`, this.formData);
  }

  deleteDolce(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  
  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Dolce[])
  }

  
}
