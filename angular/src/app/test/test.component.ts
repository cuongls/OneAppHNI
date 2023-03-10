import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CreateTestDialogComponent } from './create/create-dialog.component';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  TestDto,
  TestDtoPagedResultDto
} from './test.dto';
import {
  TestServiceProxy
} from './test.service';
import { EditTestDialogComponent } from './edit/edit-dialog.component';

class PagedTestRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  templateUrl: './test.component.html'
})

export class TestComponent extends PagedListingComponentBase<TestDto>{
  ctitle = 'angularproject1';
  tests: TestDto[] = [];
  keyword = '';
  advancedFiltersVisible = false;
  constructor(
    injector: Injector,
    private _testService: TestServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }
  create(): void {
     this.showCreateOrEditUserDialog();
  }

  edit(test: TestDto): void {
    this.showCreateOrEditUserDialog(test.id);
  }



  clearFilters(): void {
    this.keyword = '';
    // this.isActive = undefined;
    this.getDataPage(1);
  }
  protected list(
    request: PagedTestRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._testService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: TestDtoPagedResultDto) => {
        this.tests = result.items;
        this.showPaging(result, pageNumber);
      });
  }
  protected delete(test: TestDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', test.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._testService.delete(test.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
  private showCreateOrEditUserDialog(id?: number): void {
    let createOrEditDialog: BsModalRef;
    if (!id) {
      createOrEditDialog = this._modalService.show(
        CreateTestDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditDialog = this._modalService.show(
        EditTestDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditDialog.content.onSave.subscribe(() => {
      this.refresh();
      });
  }
}
