import { Component, OnInit } from '@angular/core';
import { DolceService } from 'src/app/shared/dolce.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Dolce } from 'src/app/shared/dolce.model';

@Component({
  selector: 'app-dolci-form',
  templateUrl: './dolci-form.component.html',
  styles: [
  ]
})
export class DolciFormComponent implements OnInit {

  constructor(public service:DolceService,private toastr:ToastrService){}

  ngOnInit(): void {
  }
  
  curDate = new Date();


  onSubmit(form: NgForm){
    if(this.service.formData.dolceId == 0){
      this.insertRecord(form);
    }
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postDolce().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Dolce aggiunto con successo in vetrina');
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form:NgForm){
    this.service.putDolce().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Dolce aggiornato con successo in vetrina');
      },
      err => {console.log(err);}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Dolce();
  }



}
