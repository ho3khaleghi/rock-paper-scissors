import { HubConnection } from '@microsoft/signalr';
import { HubConnectionBuilder } from '@microsoft/signalr';

export class SignalrService {
  private hubConnection: HubConnection | null = null;

  public get connection(): HubConnection | null {
    return this.hubConnection;
  }

  public async start() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:5002/rpshub')
      .withAutomaticReconnect()
      .build();

    await this.hubConnection.start();
  }

  public async stop() {
    if (this.hubConnection) {
      await this.hubConnection.stop();
    }
  }
}