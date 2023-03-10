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
    BadCellDto,
    BadCellDtoPagedResultDto
} from './badcell.dto';
import {
    BadCellServiceProxy
} from './badcell.service';
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


class PagedBadCellRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './badcell.component.html',
  styleUrls: ['../style.css']
})

export class BadCellComponent extends PagedListingComponentBase<BadCellDto>{
  viewUpload = false;
  disableUpload = true;
  ctitle = 'angularproject1';
  logUploads: UploadFileDto[] = [];
  badCells: BadCellDto[] = [];
  keyword = '';
  advancedFiltersVisible = false;
  fileToUpload: File | null = null;
  myDate = new Date();
  tuanbaocao = this.transform(this.myDate) - 1;
  nambaocao = this.myDate.getFullYear();
  loaicell = "2G";
  tuan = this.transform(this.myDate) - 1;
  nam = this.myDate.getFullYear();
  trangthai = 0;
  cell = "";

  EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  EXCEL_EXTENSION = '.xlsx';
  constructor(
    injector: Injector,
    private _badCellService: BadCellServiceProxy,
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
  xuatphieu(badcell: BadCellDto): void {
    abp.message.confirm(
      this.l('Xuất phiếu xử lý BadCell', badcell.tencell),
      undefined,
      (result: boolean) => {
        if (result) {
          this._badCellService.xuatphieu(badcell).subscribe(
            () => {
              
            }, 
            ( err : any) => {
              abp.message.error("Có lỗi xảy ra!");
            },
            () => {
              this.getDataPage(1);
              abp.message.success('Successfully');
            }
            );
        }
      }
    );
    
  }
  protected list(
    request: PagedBadCellRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;    
    this._uploadFileService
      .getAll(
        'BADCELL',
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
      this._badCellService
      .getAll(
        request.keyword,
        this.trangthai,
        this.tuan,
        this.nam,
        this.cell,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: BadCellDtoPagedResultDto) => {
        this.badCells = result.items;
        this.showPaging1(result, this.pageNumber1);
      });
  }
  
  protected delete(DIENNANG: BadCellDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', DIENNANG.tentram),
      undefined,
      (result: boolean) => {
        if (result) {
          this._badCellService.delete(DIENNANG.id).subscribe(() => {
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
    const filenameSplit =  files.item(0).name.split("_");
    if(filenameSplit.length >=8){
        this.loaicell = filenameSplit[2].replace("BadCell","");
        this.tuanbaocao = Number(filenameSplit[6]);
    }
  }
  upload(): void{
    this.viewUpload = true;
    // setTimeout( () => {       
    // }, 10000 );
    if(this.fileToUpload.name.includes("MBB_QoS_BadCell")){
        this._badCellService.upload(this.fileToUpload, this.tuanbaocao, this.nambaocao , this.loaicell).subscribe(
            () => {
              abp.message.success('Successfully');
              this.viewUpload = false;
              this.disableUpload = true;
              this.getDataPage(1);
              this.getDataPage1(1);
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
  
}
