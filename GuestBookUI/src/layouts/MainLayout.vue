<template>
  <q-layout view="lHh Lpr lFf">
    <q-header>
      <q-toolbar>
        <q-toolbar-title>Guest Book App</q-toolbar-title>
        <router-link to="/add-comment">
          <q-btn color="white" text-color="black" label="Add Comment" icon="add" rounded />
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
