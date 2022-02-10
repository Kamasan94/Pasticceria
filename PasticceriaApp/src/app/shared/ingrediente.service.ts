import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Ingrediente } from './ingrediente.model';

@Injectable({
  providedIn: 'root'
})
export class IngredienteService {

  constructor(private http:HttpClient) { }

  formData: Ingrediente = new Ingrediente();

  readonly baseUrl = 'http://localhost:5057/api/Dolci'

  list: Ingrediente[];

  postIngrediente() {
    return this.http.post(this.baseUrl,this.formData)
  }

  putIngrediente() {
    return this.http.put(`${this.baseUrl}/${this.formData.ingredienteId}`, this.formData);
  }

  deleteIngrediente(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  
  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Ingrediente[])
  }




}
