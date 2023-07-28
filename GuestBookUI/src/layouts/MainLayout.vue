<template>
  <q-layout view="lHh Lpr lFf">
    <q-header>
      <q-toolbar>
        <router-link to="/">
          <q-btn flat round color="white" icon="home" />
        </router-link>
        <q-toolbar-title>Guest Book App</q-toolbar-title>
        <router-link to="/add-comment">
          <q-btn push color="white" text-color="primary" icon="add" label="Comment"/>
        </router-link>
        <router-link to="/add-author" style="margin-left: 15px">
          <q-btn push color="white" text-color="primary" icon="add" label="Author" />
        </router-link>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { RouterLink } from 'vue-router'

export default defineComponent({
  name: 'MainLayout'
})
</script>
