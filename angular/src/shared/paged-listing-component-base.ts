import { AppComponentBase } from 'shared/app-component-base';
import { Component, Injector, OnInit } from '@angular/core';

export class PagedResultDto {
    items: any[];
    totalCount: number;
}

export class EntityDto {
    id: number;
}

export class PagedRequestDto {
    skipCount: number;
    maxResultCount: number;
}

@Component({
    template: ''
})
export abstract class PagedListingComponentBase<TEntityDto> extends AppComponentBase implements OnInit {

    public pageSize = 10;
    public pageNumber = 1;
    public totalPages = 1;
    public totalItems: number;
    public isTableLoading = false;

    public pageSize1 = 10;
    public pageNumber1 = 1;
    public totalPages1 = 1;
    public totalItems1: number;
    public isTableLoading1 = false;

    constructor(injector: Injector) {
        super(injector);
    }

    ngOnInit(): void {
        this.refresh();
        this.refresh1();
    }

    refresh(): void {
        this.getDataPage(this.pageNumber);
    }
    refresh1(): void {
        this.getDataPage1(this.pageNumber1);
    }
    public showPaging(result: PagedResultDto, pageNumber: number): void {
        this.totalPages = ((result.totalCount - (result.totalCount % this.pageSize)) / this.pageSize) + 1;

        this.totalItems = result.totalCount;
        this.pageNumber = pageNumber;
    }

    public showPaging1(result: PagedResultDto, pageNumber: number): void {
        this.totalPages1 = ((result.totalCount - (result.totalCount % this.pageSize1)) / this.pageSize1) + 1;

        this.totalItems1 = result.totalCount;
        this.pageNumber1 = pageNumber;
    }

    public getDataPage(page: number): void {
        const req = new PagedRequestDto();
        req.maxResultCount = this.pageSize;
        req.skipCount = (page - 1) * this.pageSize;

        this.isTableLoading = true;
        this.list(req, page, () => {
            this.isTableLoading = false;
        });
    }
    public getDataPage1(page: number): void {
        const req = new PagedRequestDto();
        req.maxResultCount = this.pageSize1;
        req.skipCount = (page - 1) * this.pageSize1;

        this.isTableLoading = true;
        this.list(req, page, () => {
            this.isTableLoading = false;
        });
    }

    protected abstract list(request: PagedRequestDto,  pageNumber: number, finishedCallback: Function): void;
    //protected abstract list1(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void;
    protected abstract delete(entity: TEntityDto): void;
}
