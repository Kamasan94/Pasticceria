import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Ricetta } from './ricetta.model';
import { Dolce } from './dolce.model';
@Injectable({
  providedIn: 'root'
})
export class RicettaService {

  constructor(private http:HttpClient) { }

  formData:Ricetta = new Ricetta();

  readonly baseUrl = 'http://localhost:5057/api/Ricetta'

  list : Ricetta[];

  postRicetta() {
    return this.http.post(this.baseUrl,this.formData)
  }

  putRiceta() {
    return this.http.put(`${this.baseUrl}/${this.formData.ricettaId}`, this.formData);
  }

  deleteRicetta(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  
  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Ricetta[])
  }

  getRicettaByDolce(dolce: Dolce){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Ricetta[])
     
    var returnList: Ricetta[] = [];

    for(let i=0; i<this.list.length; i++){
      if(this.list[i].dolceId == dolce.dolceId){
        returnList.push(this.list[i]);
      }
    }
    return returnList;
  }
  
}
