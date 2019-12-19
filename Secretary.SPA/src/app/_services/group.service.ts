import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grupo } from '../_models/Grupo';

@Injectable( {
  providedIn: 'root'
} )
export class GroupService
{
  private baseUrl = environment.apiUrl;

  constructor (
    private http: HttpClient
  ) { }

  getGroup ( groupId, congregationId ): Observable<Grupo>
  {
    return this.http.get<Grupo>( this.baseUrl + 'group/bygroupandcongregation/' + groupId + "&" + congregationId);
  }

  getGroups ( congregationId ): Observable<Grupo[]>
  {
    return this.http.get<Grupo[]>( this.baseUrl + 'group/allgroupscongregation/' + congregationId );
  }

  createGroup(group: Grupo) {
    return this.http.post<Grupo>( this.baseUrl + 'group/', group)
  }

  updateGroup (id: number, group: Grupo )
  {
    return this.http.put<Grupo>( this.baseUrl + 'group/' + id, group )
  }

}
