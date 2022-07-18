import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import {ChartModel} from "../_interfaces/chartmodel.model"

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data?: any[];
  public bradcastedData?: any[];

  constructor() { }

  private hubConnection: any;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                             .withUrl('https://localhost:5001/chart')
                             .withAutomaticReconnect()
                             .configureLogging(signalR.LogLevel.Information)
                             .build()
    this.hubConnection
    .start()
    .then(() => console.log('Connection started'))
    .catch((err:any) => console.log('Error while starting connection: ' + err))
  }
  //get chart data server to client load event
  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdata', (data:any) => {
      this.data = data;
      console.log(data);
    });
  }


//send chart data client to server
  public broadcastChartData = () => {
    const data = this.data?.map(m => {
      const temp = {
        data: m.data,
        label: m.label
      }
      return temp;
    });
    this.hubConnection.invoke('broadcastchartdata', data)
    .catch((err:any) => console.error(err));
  }
//get chart data server to client after click chirt.
  public addBroadcastChartDataListener = () => {
    this.hubConnection.on('broadcastchartdata', (data:any) => {
      this.bradcastedData = data;
    })
  }
}
