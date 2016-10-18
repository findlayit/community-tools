import { Injectable } from '@angular/core';

@Injectable()
export class AppSettings {
  constructor() {

  }
  private _Environment: string = "development";
  // private _Environment: string = "staging";
  // private _Environment: string = "production";

  private _proxyApiUrl_development: string = "http://proxy.communitytools";
  private _proxyApiUrl_staging: string = "http://proxy.communitytools";
  private _proxyApiUrl_production: string = "http://proxy.communitytools";
  ProxyApiUrl(): string {
    if (this._Environment == "development") {
      return this._proxyApiUrl_development;
    }
    else if (this._Environment == "staging") {
      return this._proxyApiUrl_staging;
    }
    else if (this._Environment == "production") {
      return this._proxyApiUrl_production;
    }
    return "";
  }
}
