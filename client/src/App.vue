<template>
  <div class="app">
    <h1>Guest Book</h1>
    <AddComment />
    <CommentList />
  </div>
</template>

<script>
import CommentList from './components/CommentList.vue';
import AddComment from './components/AddComment.vue';

export default {
  components: {
    CommentList,
    AddComment,
  },
};
</script>

<style>
/* Add your CSS styles here */
</style>
