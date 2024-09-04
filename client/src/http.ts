import axios, { AxiosError, AxiosResponse } from "axios";
import { SearchParamsDto } from "./DTOs/SearchParamsDto";

axios.defaults.baseURL = 'http://localhost:5055/api/';
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    getWithObject: (url: string, body: object) => axios.get(url, {'params': body}).then(responseBody),
    post: (url: string, body: object) => axios.post(url, body).then(responseBody),
    put: (url: string, body: object) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

const Search = {
    doSearch: (params: SearchParamsDto) => requests.getWithObject(`search/exact-search`, params),
}

// const Test = {
//     initiateNewTest: (technologyName: string) => requests.post(`test/initiate-new-test?techName=${technologyName}`, {}),
//     answer: (testId: number, questionId: number, answerNumber: number) => requests.post(`test/answer?testId=${testId}&questionId=${questionId}&answerNumber=${answerNumber}`, {}),
//     nextQuestion: (testId: number) => requests.get(`test/next-question?testId=${testId}`),
//     result: (testId: number) => requests.get(`test/test-result?testId=${testId}`),
//     complete: (testId: number) => requests.put(`test/complete-test?testId=${testId}`, {})
// }

const http = {
    Search
}

export default http;