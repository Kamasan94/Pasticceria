import { Component, Input, OnInit } from '@angular/core';
import { DolceService } from 'src/app/shared/dolce.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VetrinaService } from 'src/app/shared/vetrina.service';
import { Vetrina } from 'src/app/shared/vetrina.model';

//import { threadId } from 'worker_threads';

@Component({
  selector: 'app-pasticceria-form',
  templateUrl: './pasticceria-form.component.html',
  styleUrls: ['./pasticceria-form.component.css']
})

export class PasticceriaFormComponent implements OnInit {

  constructor(public service:VetrinaService, public dolceService:DolceService, private toastr:ToastrService){}

  ngOnInit(): void {
  }
  
  curDate = new Date();

  onSubmit(form: NgForm){
    if(this.service.formData.vetrinaId == 0){
      this.insertRecord(form);
    }
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postVetrina(this.curDate).subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Dolce aggiunto con successo in vetrina');
      },
      err => {this.toastr.error('Errore durante il salvataggio');}
    );
  }

  updateRecord(form:NgForm){
    this.service.putVetrina().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Dolce aggiornato con successo in vetrina');
      },
      err => {this.toastr.error('Errore in aggiornamento');}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Vetrina();
  }
}
