import { HubConnection } from '@microsoft/signalr';
import { HubConnectionBuilder } from '@microsoft/signalr';

export class SignalrService {
  private hubConnection: HubConnection | null = null;

  public get connection(): HubConnection | null {
    return this.hubConnection;
  }

  public async start() {

    try {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7081/rpshub')
      .withAutomaticReconnect()
      .build();

    await this.hubConnection.start();
    } catch (error) {
      console.error(error);
    }
  }

  // TODO: This should be changed. It is not a good practice to pass username as query string.
  public async startUserSpesific(username: string) {

    try {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`https://localhost:7081/rpshub?username=${encodeURIComponent(username)}`)
      .withAutomaticReconnect()
      .build();

    await this.hubConnection.start();
    } catch (error) {
      console.error(error);
    }
  }

  public async stop() {
    if (this.hubConnection) {
      await this.hubConnection.stop();
    }
  }
}