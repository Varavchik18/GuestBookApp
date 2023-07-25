<template>
  <q-layout view="lHh Lpr lFf">
    <q-header>
      <q-toolbar>
        <q-toolbar-title>Guest Book App</q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <!-- Router links for navigation -->
      <router-link to="/">Home</router-link>
      <router-link to="/add-comment">Add Comment</router-link>

      <!-- Router view to render the appropriate component based on the route -->
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'MainLayout'
})
</script>
