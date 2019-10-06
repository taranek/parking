export default class DataResponse{
    constructor(data,errors,isSuccess){
        this.data = data;
        this.errors = errors;
        this.isSuccess = isSuccess;
    }
}