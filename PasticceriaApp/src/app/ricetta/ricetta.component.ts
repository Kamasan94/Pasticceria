import { Component, OnInit } from '@angular/core';
import { DolceService } from '../shared/dolce.service';
import { Dolce } from '../shared/dolce.model';
import { ToastrService } from 'ngx-toastr';
import { RicettaService } from '../shared/ricetta.service';
import { Ricetta } from '../shared/ricetta.model';

@Component({
  selector: 'app-ricetta',
  templateUrl: './ricetta.component.html',
  styles: [
  ]
})
export class RicettaComponent implements OnInit {

  constructor(public service: RicettaService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Ricetta) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Sicuro di cancellare questo dolce?')) {
      this.service.deleteRicetta(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Cancellazione riuscita");
          },
          err => { console.log(err) }
        )
    }
  }

}
