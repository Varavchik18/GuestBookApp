import { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('../components/CommentList.vue') }, // Renders CommentList component on the homepage
      { path: 'add-comment', component: () => import('../components/AddComment.vue') } // Renders AddComment component on /add route
    ]
  },
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
