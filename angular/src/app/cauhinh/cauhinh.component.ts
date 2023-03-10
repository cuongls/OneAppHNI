import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CauHinhDto
} from '../cauhinh/cauhinh.dto'
import {
  CauHinhServiceProxy
} from '../cauhinh/cauhinh.service';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';

@Component({
  templateUrl: './cauhinh.component.html'
})
export class CauHinhThamSoComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  cauhinh = new CauHinhDto();
  @Output() onSave = new EventEmitter<any>();
  constructor(
    injector: Injector,
    public _cauhinhService: CauHinhServiceProxy,
  ) {
    super(injector);

  }
  ngOnInit(): void {
    this.cauhinh.acountEmailSend = abp.setting.get("CAUHINH.EMAILSEND.ACOUNT");
    this.cauhinh.passWordEmailSend = abp.setting.get("CAUHINH.EMAILSEND.PASSWORD");
    this.cauhinh.emailNhanCanhBaoDienNang = abp.setting.get("CAUHINH.DIENNANG.EMAILNHANCANHBAO");
    this.cauhinh.urlXuatPhieuDHTT = abp.setting.get("CAUHINH.BADCELL.URLXPDHTT");
  }

  save(): void {
    this.saving = true;
    console.log(this.cauhinh);
    this._cauhinhService.changeCauHinh(this.cauhinh).subscribe(
      () => {
        this.message.info(this.l('SavedSuccessfully'));
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
