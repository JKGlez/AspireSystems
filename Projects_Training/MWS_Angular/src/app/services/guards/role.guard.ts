import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { routes } from '../../app.routing';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isAuthorized(route);
  }

  private isAuthorized(route: ActivatedRouteSnapshot): boolean{
    const roles = ['Administrator','Employee'];
    const expectedRoles = route.data.expectedRoles;
    const roleMatches = roles.findIndex(role => expectedRoles.indexOf(role) !== -1);
    return (roleMatches < 0 ) ? false : true;
  }

}
