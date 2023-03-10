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
  CanhBaoDto,
  ListCanhBaoDto,
  DienNangDto,
  DienNangDtoPagedResultDto
} from './dto/diennang.dto';
import {
  DienNangServiceProxy
} from './diennang.service';
import {
  UploadFileDto,
  UploadFileDtoPagedResultDto,
  CreateUploadFileDto
} from '../log/uploadfile.dto';
import {
  UploadFileServiceProxy
} from '../log/uploadfile.service';

class PagedDIENNANGRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  templateUrl: './diennang.component.html',
  styleUrls: ['./diennang.component.css']
})

export class DienNangComponent extends PagedListingComponentBase<DienNangDto>{
  viewUpload = false;
  disableUpload = true;
  ctitle = 'angularproject1';
  logUploads: UploadFileDto[] = [];
  keyword = '';
  advancedFiltersVisible = false;
  fileToUpload: File | null = null;
  myDate = new Date();
  thangbaocao = this.myDate.getMonth() + 1;
  nambaocao = this.myDate.getFullYear();
  canhbaothuong = 20;
  canhbaokhan = 50;
  canhbaos: CanhBaoDto[] = [];
  EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  EXCEL_EXTENSION = '.xlsx';
  constructor(
    injector: Injector,
    private _DIENNANGService: DienNangServiceProxy,
    private _uploadFileService: UploadFileServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
    
  }
  clearFilters(): void {
    this.keyword = '';
    // this.isActive = undefined;
    this.getDataPage(1);
  }
  protected list(
    request: PagedDIENNANGRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;    
    this._uploadFileService
      .getAll(
        'DIENNANG',
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
  protected delete(DIENNANG: DienNangDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', DIENNANG.tentram),
      undefined,
      (result: boolean) => {
        if (result) {
          this._DIENNANGService.delete(DIENNANG.id).subscribe(() => {
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
    if(this.fileToUpload.name.includes("_OPEX_MBB")){
      this._DIENNANGService.upload(this.fileToUpload).subscribe(
        () => {
          
        }, 
        ( err : any) => {
          abp.message.error("Có lỗi xảy ra!");
          this.viewUpload = false;
          this.disableUpload = true;
        },
        () => {
          abp.message.success('Successfully');
          this.viewUpload = false;
          this.disableUpload = true;
          this.getDataPage(1);
        }
        );
    }else{
      abp.message.success('File không đúng định dạng');
    }
    this.fileToUpload = null;
  }
  exportAsExcelFile(json: any[], excelFileName: string): void {
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'buffer' });
    this.saveAsExcelFile(excelBuffer, excelFileName);
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: this.EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + this.EXCEL_EXTENSION);
  }
  laysolieucanhbao(): void{
    this.viewUpload = true;
    this._DIENNANGService
      .getDienNangBatThuongThang(
        this.thangbaocao,
        this.nambaocao,
        this.canhbaothuong,
        this.canhbaokhan
      )
      .subscribe((result: ListCanhBaoDto) => {
        this.canhbaos = result.items;
        this.viewUpload = false;
        abp.message.success('Successfully');
      }, 
        () => {
          abp.message.success('err');
        });
  }
  sendEmail(): void{
    this.viewUpload = true;
    this._DIENNANGService
      .sendEmail(
        this.thangbaocao,
        this.nambaocao,
        this.canhbaothuong,
        this.canhbaokhan
      )
      .subscribe((result: any) => {
        this.exportAsExcelFile(result, "canhbao_tieuthu_diennang_batthuong");
        this.viewUpload = false;
        abp.message.success('Successfully');
      }, 
        () => {
          abp.message.success('err');
        });
  }
}
