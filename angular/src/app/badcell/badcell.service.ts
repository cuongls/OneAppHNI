import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpRequest, HttpResponse, HttpResponseBase } from '@angular/common/http';
import {
    BadCellDto,
    BadCellDtoPagedResultDto
  } from './badcell.dto';
import * as moment from 'moment';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
@Injectable()
export class BadCellServiceProxy {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }
    /**
     * @param keyword (optional) 
     * @param skipCount (optional) 
     * @param maxResultCount (optional) 
     * @return Success
     */
    getAll(Filter: string | undefined, trangthai: number | undefined, tuan: number | undefined,
        nam: number | undefined, cell: string | undefined,
        skipCount: number | undefined, maxResultCount: number | undefined): Observable<BadCellDtoPagedResultDto> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/Getall?";
        if (Filter === null)
            throw new Error("The parameter 'keyword' cannot be null.");
        else if (Filter !== undefined)
            url_ += "Filter=" + encodeURIComponent("" + Filter) + "&";    
        if (trangthai === null)
            throw new Error("The parameter 'trangthai' cannot be null.");
        else if (trangthai !== undefined)
            url_ += "trangthai=" + encodeURIComponent("" + trangthai) + "&";    
        if (tuan === null)
            throw new Error("The parameter 'tuan' cannot be null.");
        else if (tuan !== undefined)
            url_ += "tuan=" + encodeURIComponent("" + tuan) + "&";    
        if (nam === null)
            throw new Error("The parameter 'nam' cannot be null.");
        else if (nam !== undefined)
            url_ += "nam=" + encodeURIComponent("" + nam) + "&";   
        url_ += "cell=" + encodeURIComponent("" + cell) + "&";   
        if (maxResultCount === null)
            throw new Error("The parameter 'maxResultCount' cannot be null.");
        else if (maxResultCount !== undefined)
            url_ += "MaxResultCount=" + encodeURIComponent("" + maxResultCount) + "&";
        if (skipCount === null)
            throw new Error("The parameter 'skipCount' cannot be null.");
        else if (skipCount !== undefined)
            url_ += "SkipCount=" + encodeURIComponent("" + skipCount) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll(<any>response_);
                } catch (e) {
                    return <Observable<BadCellDtoPagedResultDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<BadCellDtoPagedResultDto>><any>_observableThrow(response_);
        }));
    }

    protected processGetAll(response: HttpResponseBase): Observable<BadCellDtoPagedResultDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BadCellDtoPagedResultDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<BadCellDtoPagedResultDto>(<any>null);
    }
    delete(id: number | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/Delete?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "Id=" + encodeURIComponent("" + id) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDelete(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processDelete(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return _observableOf<void>(<any>null);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }
/**
     * @param id (optional) 
     * @return Success
     */
    get(id: number | undefined): Observable<BadCellDto> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/Get?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "Id=" + encodeURIComponent("" + id) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(<any>response_);
                } catch (e) {
                    return <Observable<BadCellDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<BadCellDto>><any>_observableThrow(response_);
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<BadCellDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BadCellDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<BadCellDto>(<any>null);
    }
    /**
     * @param body (optional) 
     * @return Success
     */
     update(body: BadCellDto | undefined): Observable<BadCellDto> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/Update";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json-patch+json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdate(<any>response_);
                } catch (e) {
                    return <Observable<BadCellDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<BadCellDto>><any>_observableThrow(response_);
        }));
    }

    protected processUpdate(response: HttpResponseBase): Observable<BadCellDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BadCellDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<BadCellDto>(<any>null);
    }
    xuatphieu(body: BadCellDto | undefined): Observable<any> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/XuatPhieuBadCell";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);
        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json-patch+json",
                "Accept": "text/plain"
            })
        };
        return this.http.request("POST", url_, options_);
        // return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
        //     return this.processxuatphieu(response_);
        // })).pipe(_observableCatch((response_: any) => {
        //     if (response_ instanceof HttpResponseBase) {
        //         try {
        //             return this.processxuatphieu(<any>response_);
        //         } catch (e) {
        //             return <Observable<string>><any>_observableThrow(e);
        //         }
        //     } else
        //         return <Observable<string>><any>_observableThrow(response_);
        // }));
    }

    protected processxuatphieu(response: HttpResponseBase): Observable<any> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(resultData200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<any>(<any>null);
    }
    upload(file: File, tuanbaocao: number, nambaocao: number, loaicell: string): Observable<HttpEvent<any>> {
        let url_ = this.baseUrl + "/api/services/app/BADCELL/Upload?";
        if (tuanbaocao === null)
            throw new Error("The parameter 'tuanbaocao' cannot be null.");
        else if (tuanbaocao !== undefined)
            url_ += "tuanbaocao=" + encodeURIComponent("" + tuanbaocao) + "&";    
        if (nambaocao === null)
            throw new Error("The parameter 'nambaocao' cannot be null.");
        else if (nambaocao !== undefined)
            url_ += "nambaocao=" + encodeURIComponent("" + nambaocao) + "&";
        if (loaicell === null)
            throw new Error("The parameter 'loaicell' cannot be null.");
        else if (loaicell !== undefined)
            url_ += "loaicell=" + encodeURIComponent("" + loaicell);
        const formData: FormData = new FormData();
    
        formData.append('file', file);
        const req = new HttpRequest('POST', url_, formData, {
          reportProgress: true,
          responseType: 'json'
        });
    
        return this.http.request(req);
      }
    
    
}
export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}
function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}