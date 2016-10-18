import { RouterConfig } from '@angular/router';
import { SignedInGuard } from './guards/signedIn.guard';

import { Home } from './components/home/home.component';
import { Login } from './components/account/login/login.component';
import { Register } from './components/account/register/register.component';

import { Groups } from './components/forums/groups/groups.component';
import { Forums } from './components/forums/forums/forums.component';
import { Threads } from './components/forums/threads/threads.component';
import { Posts } from './components/forums/posts/posts.component';

import { Unauthorised } from './components/errors/unauthorised/unauthorised.component';
import { NoContent } from './no-content';

export const routes: RouterConfig = [
  { path: '', component: Home },

  { path: 'account/login', component: Login },
  { path: 'account/register', component: Register },

  { path: 'forums', component: Groups },
  { path: 'forums/:groupName', component: Forums },
  { path: 'forums/:groupName/:forumName', component: Threads },
  { path: 'forums/:groupName/:forumName/:threadName', component: Posts },

  { path: 'unauthorised', component: Unauthorised },
  { path: '**', component: NoContent },
];
