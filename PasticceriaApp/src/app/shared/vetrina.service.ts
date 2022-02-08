import { Injectable } from '@angular/core';
import { Vetrina } from './vetrina.model';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class VetrinaService {

  constructor(private http:HttpClient) { }

  formData:Vetrina = new Vetrina();

  readonly baseUrl = 'http://localhost:5057/api/Vetrina';

  list :Vetrina[];

  postVetrina(dataVendita:Date) {
    this.formData.messaInVendita = dataVendita;
    return this.http.post(this.baseUrl,this.formData)
  }

  putVetrina() {
    return this.http.put(`${this.baseUrl}/${this.formData.vetrinaId}`, this.formData);
  }

  deleteVetrina(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  
  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Vetrina[])
  }


}
