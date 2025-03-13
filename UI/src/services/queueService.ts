import api from '../services/api';
import { JoinQueueModel } from '../models/queue/joinQueueModel';
import { LeaveQueueModel } from '../models/queue/leaveQueueModel';

export class QueueService {
  public async joinQueue(model: JoinQueueModel): Promise<void> {
    await api.post('/queue/join', model);
  }

  public async leaveQueue(model: LeaveQueueModel): Promise<void> {
    await api.post('/queue/leave', model);
  }
}
