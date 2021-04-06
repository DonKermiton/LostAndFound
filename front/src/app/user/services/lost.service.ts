import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {LostModel} from '../../share/models/Lost.model';

@Injectable({
  providedIn: 'root'
})
export class LostService {
  private url = 'lost';

  constructor(private http: HttpClient) {
  }

  getNextLostPeople(getNext: number, skip: number): Observable<LostModel[]> {
    const params = new HttpParams();
    params.set('take', `${getNext}`);
    params.set('skip', `${skip}`);

    return this.http.get<LostModel[]>(this.url + `?skip=${skip}&take=${getNext}`);
  }
}
