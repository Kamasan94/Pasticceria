import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Dolce } from 'src/app/shared/dolce.model';
import { RicettaService } from 'src/app/shared/ricetta.service';
import { Ricetta } from 'src/app/shared/ricetta.model';

@Component({
  selector: 'app-ricetta-form',
  templateUrl: './ricetta-form.component.html',
  styles: [
  ]
})
export class RicettaFormComponent implements OnInit {

  constructor(public service:RicettaService,private toastr:ToastrService){}

  ngOnInit(): void {
  }
  
  curDate = new Date();


  onSubmit(form: NgForm){
    if(this.service.formData.ricettaId == 0){
      this.insertRecord(form);
    }
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postRicetta().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Ricetta aggiunta con successo');
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form:NgForm){
    this.service.putRiceta().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Ricetta aggiornata');
      },
      err => {console.log(err);}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Ricetta();
  }



}
