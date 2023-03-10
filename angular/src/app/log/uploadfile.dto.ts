import * as moment from 'moment';


export class UploadFileDto implements IUploadFileDto {
    id: number;
    filename: string;
    filepath: string;
    description: string;
    iduser: number;
    loaifile: string;
    creationTime: Date;
    tenantId: number | undefined;
    

    constructor(data?: IUploadFileDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.filename = _data["filename"];
            this.filepath = _data["filepath"];
            this.description = _data["description"];
            this.iduser = _data["iduser"];
            this.loaifile = _data["loaifile"];
            this.creationTime = _data["creationTime"];
            this.tenantId = _data["tenantId"];
            
        }
    }

    static fromJS(data: any): UploadFileDto {
        data = typeof data === 'object' ? data : {};
        let result = new UploadFileDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["filename"] = this.filename;
        data["filepath"] = this.filepath;
        data["description"] = this.description;
        data["iduser"] = this.iduser;
        data["loaifile"] = this.loaifile;
        data["creationTime"] = this.creationTime;
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): UploadFileDto {
        const json = this.toJSON();
        let result = new UploadFileDto();
        result.init(json);
        return result;
    }
}

export interface IUploadFileDto {
    id: number;
    filename: string;
    filepath: string;
    description: string;
    iduser: number;
    loaifile: string;
    creationTime: Date;
    tenantId: number | undefined;
    
}
export class UploadFileDtoPagedResultDto implements IUploadFileDtoPagedResultDto {
    items: UploadFileDto[] | undefined;
    totalCount: number;

    constructor(data?: IUploadFileDtoPagedResultDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items.push(UploadFileDto.fromJS(item));
            }
            this.totalCount = _data["totalCount"];
        }
    }

    static fromJS(data: any): UploadFileDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new UploadFileDtoPagedResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        data["totalCount"] = this.totalCount;
        return data; 
    }

    clone(): UploadFileDtoPagedResultDto {
        const json = this.toJSON();
        let result = new UploadFileDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
export interface IUploadFileDtoPagedResultDto {
    items: UploadFileDto[] | undefined;
    totalCount: number;
}
export class CreateUploadFileDto implements ICreateUploadFileDto {
    filename: string;
    filepath: string | undefined;
    description: string;
    iduser: number | undefined;
    file: File | null;
    tenantId: number | undefined;
    

    constructor(data?: ICreateUploadFileDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.filename = _data["filename"];
            this.filepath = _data["filepath"];
            this.description = _data["description"];
            this.iduser = _data["iduser"];
            this.tenantId = _data["tenantId"];
        }
    }

    static fromJS(data: any): CreateUploadFileDto {
        data = typeof data === 'object' ? data : {};
        let result = new CreateUploadFileDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["filename"] = this.filename;
        data["filepath"] = this.filepath;
        data["description"] = this.description;
        data["iduser"] = this.iduser;
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): CreateUploadFileDto {
        const json = this.toJSON();
        let result = new CreateUploadFileDto();
        result.init(json);
        return result;
    }
}

export interface ICreateUploadFileDto {
    filename: string;
    filepath: string | undefined;
    description: string;
    iduser: number | undefined;
    file: File | null;
    tenantId: number | undefined;
}