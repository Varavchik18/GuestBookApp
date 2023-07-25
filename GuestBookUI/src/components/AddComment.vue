<template>
  <div>
    <h2>Add Comment</h2>
    <form @submit.prevent="addComment">
      <div class="form-group">
        <label for="author">Your Name:</label>
        <q-input v-model="author" id="author" />
      </div>

      <div class="form-group">
        <label for="comment">Your Comment:</label>
        <q-input v-model="text" type="textarea" id="comment" />
      </div>

      <q-btn type="submit" label="Add Comment" color="primary" />
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'AddComment',

  data () {
    return {
      author: '',
      text: ''
    }
  },

  methods: {
    addComment () {
      if (!this.author || !this.text) {
        this.$q.dialog({
          title: 'Error',
          message: 'Both name and comment text are required.',
          ok: 'OK'
        })
        return
      }
      console.log('Author:', this.author)
      console.log('Comment Text:', this.text)

      this.author = ''
      this.text = ''
    }
  }
})
</script>

<style>
.form-group {
  margin-bottom: 10px;
}
</style>
