import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  TestDto,
  TestDtoPagedResultDto,
  CreateTestDto
} from '../../test/test.dto'
import {
  TestServiceProxy
} from '../../test/test.service';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';

@Component({
  templateUrl: './create-dialog.component.html'
})
export class CreateTestDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  test = new CreateTestDto();

  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _testService: TestServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    
  }
//test__test
  save(): void {
    this.saving = true;
    this._testService.create(this.test).subscribe(
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
