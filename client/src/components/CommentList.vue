<template>
  <div>
    <h2>Comments</h2>
    <div v-for="comment in comments" :key="comment.id" class="comment">
      <strong>{{ comment.author }}</strong> - {{ comment.datePosted }}
      <p>{{ comment.text }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      comments: [
        { id: 1, author: "John Doe", datePosted: "2023-07-25", text: "This is the first comment." },
        // Add more sample comments here if needed
      ],
    };
  },
};
</script>

<style>
/* Add your CSS styles here */
</style>
