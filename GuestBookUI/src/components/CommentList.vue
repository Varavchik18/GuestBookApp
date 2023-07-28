<template>
  <div class="q-pa-md">
    <div class="q-gutter-y-md">
      <q-card>
        <q-tabs
          v-model="tab"
          class=" text-grey-7"
          align="justify"
        >
          <q-tab name="comments" label="Comments" icon="comment"/>
          <q-tab name="authors" label="Authors" icon="person"/>
        </q-tabs>

        <q-tab-panels v-model="tab" animated>
          <q-tab-panel name="comments">
            <div class="q-pa-md row items-start q-gutter-md">
              <div v-for="comment in comments" :key="comment.idComment">
                <q-card class="my-card bg-grey-9 text-white" flat bordered round>
                  <q-card-section horizontal>
                    <q-card-section class="q-pt-xs">
                      <div class="text-h5 q-mt-sm q-mb-xs title-container">
                        {{ comment.title }}
                      </div>
                      <div class="text-caption text-grey-4 description-container">
                        {{ comment.description }}
                      </div>
                    </q-card-section>

                    <!-- <q-card-section class="col-5 card-image">
                      <q-img
                        class="rounded-borders image-container"
                        :src="comment.imageUrl"
                      />
                    </q-card-section> -->
                  </q-card-section>

                  <q-separator />
                    <q-card-section class="col-5 card-image" >
                      <q-chip>
                        <q-avatar icon="person" color="red" text-color="white"></q-avatar>
                        {{ comment.author.firstName + ' ' + comment.author.lastName }}
                      </q-chip>
                    </q-card-section>
                  <q-separator />

                  <q-card-actions>
                    <q-btn icon="event" round color="primary">
                      <q-tooltip content-class="button-tooltip">
                        <div class="button-tooltip">
                          Update Comment Date
                        </div>
                      </q-tooltip>
                      <q-popup-proxy
                        @before-show="updateProxyDate(comment.dateTimeCreated)"
                        cover
                        transition-show="scale"
                        transition-hide="scale"
                      >
                        <q-date v-model="proxyDate">
                          <div class="row items-center justify-end q-gutter-sm">
                            <q-btn label="Cancel" color="primary" flat v-close-popup />
                            <q-btn
                              label="OK"
                              color="primary"
                              flat
                              @click="updateCommentDate(comment.idComment, proxyDate)"
                              v-close-popup
                            />
                          </div>
                        </q-date>
                      </q-popup-proxy>
                    </q-btn>
                    <div style="margin-left: 10px">
                      {{ formatDateTimeToUs(comment.dateTimeCreated) }}
                    </div>
                    <q-dialog v-model="showEditCommentPopup" >
                      <q-card style="min-width: 350px">
                        <q-card-section class="q-pt-none" style="margin-top: 15px">
                          <q-input label="Title" stack-label dense v-model="selectedComment.title" :rules="titleRules" autogrow  counter/>
                        </q-card-section>

                        <q-card-section class="q-pt-none">
                          <q-input label="Description" stack-label dense v-model="selectedComment.description" :rules="descriptionRules" autogrow  counter />
                        </q-card-section>
                        <q-card-actions align="right" class="text-primary">
                          <q-btn flat label="Cancel" v-close-popup />
                          <q-btn
                            flat
                            label="Save Changes"
                            @click="onSaveChanges"
                            v-close-popup
                            :disabled="hasActiveErrors" />
                        </q-card-actions>
                      </q-card>
                    </q-dialog>
                    <q-btn
                      style="margin-left: auto"
                      color="secondary"
                      icon="edit"
                      rounded
                      @click="openEditPopup(comment)"
                    >
                      <q-tooltip>
                        <div class="button-tooltip">
                          Edit
                        </div>
                      </q-tooltip>
                    </q-btn>
                    <q-btn
                      color="red-5"
                      icon="delete"
                      rounded
                      @click="deleteComment(comment)"
                    >
                      <q-tooltip>
                        <div class="button-tooltip">
                          Delete
                        </div>
                      </q-tooltip>
                    </q-btn>
                  </q-card-actions>
                </q-card>
              </div>
            </div>
          </q-tab-panel>

          <q-tab-panel name="authors">
            CLICK ON FIELDS TO EDIT THEM :3 <br />
            JUST TO SHOW ANOTHER FUNCTIONALITY
            <div class="q-pa-md row items-start q-gutter-md">
              <div v-for="author in authors" :key="author.idAuthor">
                <q-card class="my-card bg-grey-9 text-white" flat bordered round>
                  <q-card-section>
                    <div class="text-h6">
                      {{author.firstName }}
                      <q-popup-edit
                        v-model="author.firstName"
                        buttons
                        label-set="Save"
                        label-cancel="Close"
                        :validate="authorFirstNameValidation"
                        @before-hide="resetError('errorFirstName', 'errorFirstNameMessage')"
                        @save="onAuthorDataChange(author)"
                        v-slot="scope"
                      >
                        <q-input
                          type="text"
                          v-model="scope.value"
                          hint="Name should be less than 50 characters length"
                          :error="errorFirstName"
                          :error-message="errorFirstNameMessage"
                          maxlength="50"
                          dense
                          counter
                          autofocus
                          @update:model-value="setAuthorFirstName(scope, author)"
                        />
                      </q-popup-edit>
                    </div>
                    <div class="text-h6">
                      {{author.lastName }}
                      <q-popup-edit
                        v-model="author.lastName"
                        buttons
                        label-set="Save"
                        label-cancel="Close"
                        :validate="authorLastNameValidation"
                        @before-hide="resetError('errorLastName', 'errorLastNameMessage')"
                        @save="onAuthorDataChange(author)"
                        v-slot="scope"
                      >
                        <q-input
                          type="text"
                          v-model="scope.value"
                          hint="Name should be less than 50 characters length"
                          :error="errorLastName"
                          :error-message="errorLastNameMessage"
                          maxlength="50"
                          dense
                          counter
                          autofocus
                          @update:model-value="setAuthorLastName(scope, author)"
                        />
                      </q-popup-edit>
                    </div>
                  </q-card-section>

                  <q-card-section>
                  <q-chip>
                      <q-avatar icon="mail" color="white" text-color="black"/>
                      {{author.email}}
                      <q-popup-edit
                        v-model="author.email"
                        buttons
                        label-set="Save"
                        label-cancel="Close"
                        @save="onAuthorDataChange(author)"
                        v-slot="scope"
                      >
                        <q-input
                          type="text"
                          v-model="scope.value"
                          hint="Email should be less than 100 characters length"
                          maxlength="100"
                          dense
                          counter
                          autofocus
                          @update:model-value="setAuthorEmail(scope, author)"
                        />
                      </q-popup-edit>
                    </q-chip>
                  </q-card-section>

                  <q-card-section>
                  <q-chip>
                      <q-avatar icon="phone" color="white" text-color="black"/>
                      {{author.phone}}
                      <q-popup-edit
                        v-model="author.phone"
                        buttons
                        label-set="Save"
                        label-cancel="Close"
                        @save="onAuthorDataChange(author)"
                        v-slot="scope"
                      >
                        <q-input
                          type="text"
                          v-model="scope.value"
                          hint="Phone should be less or equal than 13 characters length"
                          maxlength="13"
                          dense
                          counter
                          autofocus
                          @update:model-value="setAuthorPhone(scope, author)"
                        />
                      </q-popup-edit>
                    </q-chip>
                  </q-card-section>

                  <q-separator/>

                  <q-card-actions>
                      <q-btn
                        style="margin-left: auto; margin-right: 15px"
                        color="red-5"
                        icon="delete"
                        rounded
                        @click="onDeleteAuthor(author)"
                      >
                        <q-tooltip>
                          <div class="button-tooltip">
                            Delete
                          </div>
                        </q-tooltip>
                      </q-btn>
                  </q-card-actions>
                </q-card>
              </div>
            </div>
          </q-tab-panel>
        </q-tab-panels>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { Notify, Dialog } from 'quasar'
import axios from 'axios'
import { BASE_URL } from '../api.config'
import { IAuthor } from './types'
import { _ } from 'lodash'

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
  name: 'CommentList',

  data () {
    return {
      comments: [] as IComment[],
      authors: [] as IAuthor[],
      proxyDate: ref('2019/03/01'),
      date: ref(new Date()),
      showEditCommentPopup: ref(false),
      selectedComment: ref(null as IComment),
      tab: ref('comments'),
      errorFirstName: ref(false),
      errorLastName: ref(false),
      errorEmail: ref(false),
      errorPhone: ref(false),
      errorFirstNameMessage: ref(''),
      errorLastNameMessage: ref(''),
      errorEmailMessage: ref(''),
      errorPhoneMessage: ref('')
    }
  },

  computed: {
    titleRules () {
      return [
        (v) => !!v || 'Title is required.',
        (v) => (v && v.length <= 50) || 'Title should be less than 50 characters.'
      ]
    },
    descriptionRules () {
      return [
        (v) => !v || v.length <= 500 || 'Description should be less than 500 characters.'
      ]
    },
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
    async fetchCommentsList () {
      try {
        const response = await axios.get<IComment[]>(`${BASE_URL}/comments/list`)
        this.comments = response.data.map((comment) => {
          const dateTimeCreated = new Date(comment.dateTimeCreated)
          const imageUrl = comment.imageUrl ? comment.imageUrl : this.getRandomImage()

          return {
            ...comment,
            dateTimeCreated,
            imageUrl
          }
        })
      } catch (error) {
        this.showErrorMessage(error)
      }
    },

    async fetchAuthorsList () {
      try {
        const response = await axios.get<IAuthor[]>(`${BASE_URL}/authors/list`)
        this.authors = response.data
        this.fakeAuthors = response.data
      } catch (error) {
        this.showErrorMessage(error)
      }
    },

    getRandomImage (): string {
      return `https://picsum.photos/1920/1080?random=${Math.random()}`
    },

    async updateCommentDate (idComment: number, date: Date) {
      try {
        await axios.put(`${BASE_URL}/comments/${idComment}/updateDate`, {
          dateTimeCreated: new Date(date).toISOString()
        })
        this.fetchCommentsList()
      } catch (error) {
        this.showErrorMessage(error, 'Error updating comment date: ')
      }
    },

    parseDateStringToDateTimeOffset (dateString: string) {
      const [year, month, day] = dateString.split('/').map(Number)

      const date = new Date(year, month - 1, day)

      const timestamp = date.getTime()

      return { dateTime: new Date(timestamp).toISOString() }
    },

    getDateForPicker (dateTime: string): string {
      const dateObject = new Date(dateTime)

      const year = dateObject.getFullYear()
      const month = dateObject.getMonth() + 1
      const day = dateObject.getDate()

      const formattedMonth = month.toString().padStart(2, '0')
      const formattedDay = day.toString().padStart(2, '0')

      const formattedDate = `${year}/${formattedMonth}/${formattedDay}`

      return formattedDate
    },

    formatDateTimeToUs (dateTime: string) {
      const options: Intl.DateTimeFormatOptions = {
        day: '2-digit',
        month: 'short',
        year: 'numeric'
      }

      const dateObject = new Date(dateTime)

      const formattedDate = dateObject.toLocaleDateString('en-US', options)

      return formattedDate
    },

    updateProxyDate (date: Date) {
      this.proxyDate = this.getDateForPicker(date.toISOString())
    },

    openEditPopup (comment) {
      this.selectedComment = { ...comment }

      this.showEditCommentPopup = true
    },

    async onAuthorDataChange (author: IAuthor) {
      try {
        await axios.put(`${BASE_URL}/authors/${author.idAuthor}/update`, {
          firstName: author.firstName,
          lastName: author.lastName,
          email: author.email,
          phone: author.phone
        })
        this.showSucceedMessage('Author updated successfully!')
      } catch (error) {
        this.showErrorMessage(error, 'Error updating author: ')
      }

      this.fetchAuthorsList()
    },

    deleteComment (comment) {
      Dialog.create({
        title: 'Delete comment',
        message: 'Are you sure you want to delete this comment?',
        cancel: true,
        persistent: true
      }).onOk(async () => {
        try {
          await axios.delete(`${BASE_URL}/comments/${comment.idComment}/delete`)
          this.showSucceedMessage('Comment deleted successfully!')
          this.fetchCommentsList()
        } catch (error) {
          this.showErrorMessage(error, 'Error deleting comment: ')
        }
      })
    },

    onDeleteAuthor (author: IAuthor) {
      Dialog.create({
        title: 'Delete author',
        message: 'Are you sure you want to delete this author?',
        cancel: true,
        persistent: true
      }).onOk(async () => {
        try {
          await axios.delete(`${BASE_URL}/authors/${author.idAuthor}/delete`)
          this.showSucceedMessage('Author deleted successfully!')
          this.fetchAuthorsList()
        } catch (error) {
          this.showErrorMessage(error, 'Error deleting author: ')
        }
      })
    },

    cancelEdit () {
      this.editPopupVisible = false
    },

    async onSaveChanges () {
      if (!this.selectedComment) return

      const { idComment, imageUrl } = this.selectedComment

      try {
        await axios.put(`${BASE_URL}/comments/${idComment}/update`, {
          title: this.selectedComment.title,
          description: this.selectedComment.description,
          imageUrl
        })

        const originalComment = this.comments.find((comment) => comment.idComment === idComment)
        if (originalComment) {
          originalComment.title = this.selectedComment.title
          originalComment.description = this.selectedComment.description
        }

        this.showSucceedMessage('Comment updated successfully!')
      } catch (error) {
        this.showErrorMessage(error, 'Error updating comment:')
      }

      this.showEditCommentPopup = false
    },

    showErrorMessage (error: any, message: string): void {
      Notify.create({
        message: `${message} ${error.response.data}`,
        color: 'negative',
        icon: 'warning'
      })
    },

    showSucceedMessage (message: string): void {
      Notify.create({
        message: `${message}`,
        color: 'positive',
        icon: 'check'
      })
    },

    resetError (fieldName, errorMessage) {
      this[fieldName] = false
      this[errorMessage] = ''
    },

    authorFirstNameValidation (val) {
      if (_.isNil(val) || _.isEmpty(_.trim(val))) {
        this.errorFirstName = true
        this.errorFirstNameMessage = 'First Name is required'
        return false
      }
      this.errorFirstName = false
      this.errorFirstNameMessage = ''
      return true
    },

    authorLastNameValidation (val) {
      if (_.isNil(val) || _.isEmpty(_.trim(val))) {
        this.errorLastName = true
        this.errorLastNameMessage = 'Last Name is required'
        return false
      }
      this.errorLastName = false
      this.errorLastNameMessage = ''
      return true
    },

    setAuthorFirstName (scope: any, author: IAuthor) {
      if (this.authorFirstNameValidation(scope.value)) {
        author.firstName = scope.value
      }
    },

    setAuthorLastName (scope: any, author: IAuthor) {
      if (this.authorLastNameValidation(scope.value)) {
        author.lastName = scope.value
      }
    },

    setAuthorEmail (scope: any, author: IAuthor) {
      author.email = scope.value
    },

    setAuthorPhone (scope: any, author: IAuthor) {
      author.phone = scope.value
    }
  },

  async mounted () {
    await this.fetchCommentsList().catch((error) => {
      console.error('Error fetching comments list:', error)
    })

    await this.fetchAuthorsList().catch((error) => {
      console.error('Error fetching authors list:', error)
    })
  }
})
</script>

<style lang="sass" scoped>
.my-card
  width: 100%
  width: 450px

.description-container
  margin-top: 15px
  max-height: 200px
  overflow-y: auto

.title-container
  max-width: 200px
  overflow-x: auto

.image-container
  height: 200px
  width: 100%
  object-fit: cover
  object-position: right
  border-radius: 8px

.card-image
  display: flex
  justify-content: flex-end
  align-items: flex-start

::-webkit-scrollbar
  width: 8px
  height: 8px

::-webkit-scrollbar-thumb
  background-color: #888
  border-radius: 4px

::-webkit-scrollbar-thumb:hover
  background-color: #555

.button-tooltip
  font-size: 12px
</style>
