<template>
  <div>
    <h2>Add Comment</h2>
    <div>
      <input v-model="author" type="text" placeholder="Your Name" />
      <textarea v-model="text" placeholder="Your Comment"></textarea>
      <button @click="addComment">Add Comment</button>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      author: '',
      text: '',
    };
  },
  methods: {
    addComment() {
      if (!this.author || !this.text) {
        alert('Both name and comment text are required.');
        return;
      }

      // Here you can implement the logic to send the comment data to the backend
      // For now, we'll just log the comment data to the console
      console.log('Author:', this.author);
      console.log('Comment Text:', this.text);

      // Clear the input fields after adding the comment
      this.author = '';
      this.text = '';
    },
  },
};
</script>

<style>
/* Add your CSS styles here */
</style>
