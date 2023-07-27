<template>
    <q-dialog>
        <q-card>
            <q-card-section class="q-pt-none" style="margin-top: 15px">
            <q-input
                label="Title"
                stack-label
                dense
                v-model="comment.title"
                :rules="titleRules"
                autogrow
                clearable
                counter
            />
            </q-card-section>

            <q-card-section class="q-pt-none">
            <q-input
                label="Description"
                stack-label
                dense
                v-model="comment.description"
                :rules="descriptionRules"
                autogrow
                clearable
                counter
            />
            </q-card-section>
            <q-card-actions align="right" class="text-primary">
            <q-btn flat label="Cancel" @click="closeDialog" />
            <q-btn
                flat
                label="Save Changes"
                @click="saveChanges"
                :disabled="hasActiveErrors"
            />
            </q-card-actions>
        </q-card>
  </q-dialog>
</template>

<script lang="ts">
import { defineComponent, PropType, ref } from 'vue'
import axios from 'axios'
import { BASE_URL } from '../api.config'

interface IComment {
  idComment: number;
  title: string | null;
  description: string | null;
  dateTimeCreated: Date;
  dateTimeUpdated: Date;
  imageUrl: string | null;
  author: {
    idAuthor: number;
    firstName: string | null;
    lastName: string | null;
    email: string | null;
    phone: string | null;
  };
}

export default defineComponent({
  name: 'EditCommentDialog',

  props: {
    selectedComment: {
      type: Object as PropType<IComment>,
      required: true
    }
  },

  data () {
    return {
      titleRules: [
        (v: string) => !!v || 'Title is required.',
        (v: string) => (v && v.length <= 50) || 'Title should be less than 50 characters.'
      ],
      descriptionRules: [
        (v: string) => !v || v.length <= 500 || 'Description should be less than 500 characters.'
      ],
      comment: ref(this.selectedComment)
    }
  },

  computed: {
    isTitleValid () {
      return this.selectedComment.title && this.selectedComment.title.length <= 50
    },
    isDescriptionValid () {
      return !this.selectedComment.description || this.selectedComment.description.length <= 500
    },
    hasActiveErrors () {
      return !this.isTitleValid || !this.isDescriptionValid
    }
  },

  methods: {
    async saveChanges () {
      if (!this.selectedComment) return

      const { idComment, imageUrl } = this.selectedComment

      try {
        await axios.put(`${BASE_URL}/comments/${idComment}/update`, {
          title: this.selectedComment.title,
          description: this.selectedComment.description,
          imageUrl
        })

        const originalComment = this.comments.find(
          (comment) => comment.idComment === idComment
        )
        if (originalComment) {
          originalComment.title = this.selectedComment.title
          originalComment.description = this.selectedComment.description
        }

        this.showSucceedMessage('Comment updated successfully!')
        this.$emit('close') // Close the popup on successful update
      } catch (error) {
        this.showErrorMessage(error, 'Error updating comment:')
      }
    },

    closeDialog () {
      this.$emit('close')
    }
  },

  mounted () {
    console.log(this.selectedComment)
  }
})
</script>
