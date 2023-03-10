import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
    TramLoaiTruDto,
    TramLoaiTruDtoPagedResultDto
} from './tramloaitru.dto';
import {
    TramLoaiTruServiceProxy
} from './tramloaitru.service';
import {
  UploadFileDto,
  UploadFileDtoPagedResultDto,
  CreateUploadFileDto
} from '../log/uploadfile.dto';
import {
  UploadFileServiceProxy
} from '../log/uploadfile.service';
import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';


class PagedTramLoaiTruRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  templateUrl: './tramloaitru.component.html',
  styleUrls: ['../style.css']
})

export class TramLoaiTruComponent extends PagedListingComponentBase<TramLoaiTruDto>{
  viewUpload = false;
  disableUpload = true;
  ctitle = 'angularproject1';
  logUploads: UploadFileDto[] = [];
  keyword = '';
  advancedFiltersVisible = false;
  fileToUpload: File | null = null;


  EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  EXCEL_EXTENSION = '.xlsx';
  constructor(
    injector: Injector,
    private _tramloaitruService: TramLoaiTruServiceProxy,
    private _uploadFileService: UploadFileServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
    
  }
  transform(value: Date): number {
    return moment(value).week();
    }
  clearFilters(): void {
    this.keyword = '';
    // this.isActive = undefined;
    this.getDataPage(1);
  }
  protected list(
    request: PagedTramLoaiTruRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;    
    this._uploadFileService
      .getAll(
        'TRAMLOAITRU',
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: UploadFileDtoPagedResultDto) => {
        this.logUploads = result.items;
        this.showPaging(result, pageNumber);
      });
  }
  protected delete(DIENNANG: TramLoaiTruDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', DIENNANG.sitename),
      undefined,
      (result: boolean) => {
        if (result) {
          this._tramloaitruService.delete(DIENNANG.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
  handleFileInput(files: FileList): void {    
    this.fileToUpload = files.item(0);
    this.disableUpload = false;

  }
  upload(): void{
    this.viewUpload = true;
    // setTimeout( () => {       
    // }, 10000 );
    if(this.fileToUpload.name.includes("tramloaitru")){
        this._tramloaitruService.upload(this.fileToUpload).subscribe(
            () => {
              abp.message.success('Successfully');
              this.viewUpload = false;
              this.disableUpload = true;
              this.getDataPage(1);
            }, 
            () => {
              abp.message.success('err');
            }
            );
    }else{
        abp.message.success('File không đúng định dạng');
    }
    
      this.fileToUpload = null;
  }
  
}
