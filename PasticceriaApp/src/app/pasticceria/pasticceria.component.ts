import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DolceService } from '../shared/dolce.service';
import { Vetrina } from '../shared/vetrina.model';
import { VetrinaService } from '../shared/vetrina.service';

@Component({
  selector: 'app-pasticceria',
  templateUrl: './pasticceria.component.html',
  styles: [
  ]
})
export class PasticceriaComponent implements OnInit {

  constructor(public service: VetrinaService, public dolceService: DolceService, private toastr: ToastrService) { }
  
  ngOnInit(): void {
    this.service.refreshList();
    this.dolceService.refreshList();
  }

  populateForm(selecetedRecord:Vetrina){
    this.service.formData = Object.assign({},selecetedRecord);
  }
  

  onDelete(id:number){
    if(confirm("Sicuro di cancellare questa vendita?"))
    {
      this.service.deleteVetrina(id).subscribe(
        res=>{
          this.service.refreshList();
          this.toastr.error("Venita cancellata con successo")
        },
        err => {console.log(err)}
      )
    }
  }

}
