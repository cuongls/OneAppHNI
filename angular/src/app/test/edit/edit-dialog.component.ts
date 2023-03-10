import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  TestDto,
  TestDtoPagedResultDto,
  CreateTestDto
} from '../../test/test.dto'
import {
  TestServiceProxy
} from '../../test/test.service';

@Component({
  templateUrl: './edit-dialog.component.html'
})
export class EditTestDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  test = new TestDto();
  
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _testService: TestServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._testService.get(this.id).subscribe((result) => {
      this.test = result;
    });
  }

  save(): void {
    this.saving = true;


    this._testService.update(this.test).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
