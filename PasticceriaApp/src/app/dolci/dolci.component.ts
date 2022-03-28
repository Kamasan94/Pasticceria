import { Component, OnInit } from '@angular/core';
import { DolceService } from '../shared/dolce.service';
import { Dolce } from '../shared/dolce.model';
import { ToastrService } from 'ngx-toastr';
import { RicettaService } from '../shared/ricetta.service';

@Component({
  selector: 'app-dolci',
  templateUrl: './dolci.component.html',
  styles: [
  ]
})
export class DolciComponent implements OnInit {

  constructor(public service: DolceService, private toastr: ToastrService, public ricettaService: RicettaService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Dolce) {
    this.service.formData = Object.assign({}, selectedRecord);
    this.ricettaService.list = Object.assign({}, this.ricettaService.getRicettaByDolce(selectedRecord))
  }


  onDelete(id:number){
    if (confirm('Sicuro di cancellare questo dolce?')) {
      this.service.deleteDolce(id)
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
