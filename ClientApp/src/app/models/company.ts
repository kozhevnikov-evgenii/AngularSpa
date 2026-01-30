import type { Activity } from './activity';

export interface Company {
  id: string;
  name: string;
  activityId: string;
  activity?: Activity;
}
