export class CauHinhDto implements ICauHinhDto {
    acountEmailSend: string;
    passWordEmailSend: string | undefined;
    emailNhanCanhBaoDienNang: string;
    urlXuatPhieuDHTT: string;
    

    constructor(data?: ICauHinhDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.acountEmailSend = _data["acountEmailSend"];
            this.passWordEmailSend = _data["passWordEmailSend"];
            this.emailNhanCanhBaoDienNang = _data["emailNhanCanhBaoDienNang"];         
            this.urlXuatPhieuDHTT = _data["urlXuatPhieuDHTT"];           
        }
    }

    static fromJS(data: any): CauHinhDto {
        data = typeof data === 'object' ? data : {};
        let result = new CauHinhDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["acountEmailSend"] = this.acountEmailSend;
        data["passWordEmailSend"] = this.passWordEmailSend;
        data["emailNhanCanhBaoDienNang"] = this.emailNhanCanhBaoDienNang;
        data["urlXuatPhieuDHTT"] = this.urlXuatPhieuDHTT;
        return data; 
    }

    clone(): CauHinhDto {
        const json = this.toJSON();
        let result = new CauHinhDto();
        result.init(json);
        return result;
    }
}

export interface ICauHinhDto {
    acountEmailSend: string;
    passWordEmailSend: string | undefined;
    emailNhanCanhBaoDienNang: string;
    urlXuatPhieuDHTT: string;
}