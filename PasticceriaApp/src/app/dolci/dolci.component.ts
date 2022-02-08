import { Component, OnInit } from '@angular/core';
import { DolceService } from '../shared/dolce.service';
import { Dolce } from '../shared/dolce.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dolci',
  templateUrl: './dolci.component.html',
  styles: [
  ]
})
export class DolciComponent implements OnInit {

  constructor(public service: DolceService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Dolce) {
    this.service.formData = Object.assign({}, selectedRecord);
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
